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
}