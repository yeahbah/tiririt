import { HttpParams } from '@angular/common/http';

export class PagingParam {
    pageIndex: number;
    pageSize: number;    
    sortColumn?: string;
    sortOrder?: string;
    filterColumn?: string;
    filterQuery?: string;

    constructor() {
        this.pageIndex = 0;
        this.pageSize = 10;            
    }

    toHttpParams(): HttpParams {
        let result = new HttpParams()
            .set('pageIndex', this.pageIndex.toString())
            .set('pageSize', this.pageSize.toString())
            
        if (this.sortColumn) {            
            result = result.set('sortColumn', this.sortColumn);
            if (this.sortOrder) {
                result = result.set('sortOrder', this.sortOrder)
            }
        }        

        if (this.filterColumn) {
            result = result.set('filterColumn', this.filterColumn);
            if (this.filterQuery) {
                result = result.set('filterQuery', this.filterQuery);
            }
        }
        return result;
    }
}