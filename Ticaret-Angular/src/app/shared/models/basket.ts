import {v4 as uuidv4} from 'uuid';


   export interface IBasketItem {
       id: number;
       productName: string;
       quantity: number;
       price: number;
       pictureUrl: string;
       brand: string;
       type: string;
   }

   export interface IBasket {
       id: string;
       items: IBasketItem[];
       clientSecret?:string;
       paymentIntentId?:string;
       deliveryMethodId?:number;
       shippingPrice?:number;
   }

   export class Basket implements IBasket {
      id:string=uuidv4();
      items: IBasketItem[]=[];
      
   }

   export interface IBasketTotals{
       shipping:number;
       subTotal:number;
       total:number;
   }


