import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'striphtml'
})
export class StripHtmlPipe implements PipeTransform {
    transform(value: string, ...args: any[]): any {
        return value.replace(/(<([^>]+)>|&#\d+;)/ig, "");
    }
}