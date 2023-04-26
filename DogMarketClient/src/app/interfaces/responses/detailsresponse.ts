import { Productsresponse } from "./productsresponse";

export interface Detailsresponse {
  id: string;
  price: number;
  quantity: number;
  carid: string;
  productId: string;
  product?: Productsresponse;
  purchaseId?: string;
}
