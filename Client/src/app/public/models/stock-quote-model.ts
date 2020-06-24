export interface IStockQuoteModel {
    stockQuoteId: number;
    stockId: number;
    tradeDate: Date;
    open: number;
    high: number;
    low: number;
    close: number;
    volume: number;
    netForeignBuy?: number;
}