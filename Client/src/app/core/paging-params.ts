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
        const result = new HttpParams()
            .set('pageIndex', this.pageIndex.toString())
            .set('pageSize', this.pageSize.toString());        
        if (this.sortColumn) {
            result.set('sortColumn', this.sortOrder);
            if (this.sortOrder) {
                result.set('sortOrder', this.sortOrder)
            }
        }        

        if (this.filterColumn) {
            result.set('filterColumn', this.filterColumn);
            if (this.filterQuery) {
                result.set('filterQuery', this.filterQuery);
            }
        }

        return result;
    }
}