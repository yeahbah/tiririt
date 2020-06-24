export interface IStockModel {
    stockId: number;
    symbol: string;
    name: string;
    sectorId?: number;
    lastTradeDate?: Date;
    lastTradePrice?: number;
    previousClose?: number;
    open?: number;
    high?: number;
    low?: number;
    netForeignBuy?: number;
    isWatchedByUser: boolean;
    watchersCount: number;
    pointsChange?: number;
    percentChange?: number;
    volume?: number;
}