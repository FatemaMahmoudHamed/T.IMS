import {customer} from "./customer";

export class incident  {
   id?:number=0;
   customer!:customer;
   customerId?:number;
   details!:string;
   read !:boolean;
}
