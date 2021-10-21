import { IProduct } from "./IProduct";

export interface IPagination {
    pageIndex: number;
    pageSixe: number;
    count: number;
    data: IProduct[];
}