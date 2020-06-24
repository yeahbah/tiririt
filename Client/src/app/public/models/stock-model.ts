export interface IStockModel {
    stockId: number;
    symbol: string;
    name: string;
    sectorId?: number;
    lastTradeDate?: Date;
    lastTradePrice?: number;
    open?: number;
    high?: number;
    low?: number;
    netForeignBuy?: number;
}