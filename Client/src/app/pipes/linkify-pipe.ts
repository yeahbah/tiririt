import { Pipe, PipeTransform, SecurityContext } from '@angular/core';
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

        // process images
        let ready = false;    // dumb lol

        // images
        result = result.replace(/(https?:\/\/.*\.(?:png|jpg|gif))/g, (match) => {
            ready = true;
            return `<img src="${match}" alt="${match}" class="post-image">`
        });

        // youtube
        // const youtubeUrl = (/https?:\/\/(www\.youtube\.com\/watch\?v=)(.+)/g).exec(result);
        // if (youtubeUrl) {
        //     result = result.replace(youtubeUrl[0], (match)=> {
        //         ready = true;            
        //         console.log(youtubeUrl);
        //         return `<br/><iframe width="420" height="315"
        //                     src="https://www.youtube.com/embed/${youtubeUrl[2]}">
        //                 </iframe>`
        //     });
        // }

        if (!ready) {
            result = result.replace(/https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)/g, (match) => {
                return `<a href="${match}" target="_blank">${match}</a>`;
            });
        }
     
        // result = this.domSanitizer.sanitize(SecurityContext.SCRIPT, result);        
        return this.domSanitizer.sanitize(SecurityContext.HTML, result);

    }

}
