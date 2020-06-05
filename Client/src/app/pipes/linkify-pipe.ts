import { Pipe, PipeTransform } from '@angular/core';
import { RouterLink } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';

@Pipe({
    name: "linkify"
})
export class LinkifyPipe implements PipeTransform{
    constructor(private domSanitizer: DomSanitizer) {

    }

    transform(value: string, ...args: any[]): any {        
        let result = value.replace(/[\$|@|\#][(\^)a-zA-Z]+/g, (match) => {            
            const linkParam = match.replace(/[\$|@|\#]/g, "");
            const linkIndicator = match[0];
            switch(linkIndicator)
            {
                case '$':
                    return `<a href="/stock/${linkParam}">${match}</a>`;
                case '@':
                    return `<a href="/user/${linkParam}">${match}</a>`;
                case '#':
                    return `<a href="/tag/${linkParam}">${match}</a>`;
            } 

        });
        return this.domSanitizer.bypassSecurityTrustHtml(result);        
    }

}
