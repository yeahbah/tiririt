import { StockViewModel } from '../models/stock-view-model';

export interface WatchlistModel {
    watchListId: number;
    watchListName: string;
    userId: number;
    stocks: StockViewModel[];
}
