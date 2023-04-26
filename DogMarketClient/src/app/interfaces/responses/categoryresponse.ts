import { Productsresponse } from "./productsresponse";

export interface Categoryresponse {
  id: number;
  name: string;
  description: string;
  categoryProducts?: Productsresponse[];
}
