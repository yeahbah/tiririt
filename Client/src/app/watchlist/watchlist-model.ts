import { IStockModel } from '../public/models/stock-model';

export interface WatchlistModel {
    watchListId: number;
    watchListName: string;
    userId: number;
    stocks: IStockModel[];
}
