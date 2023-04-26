import { Detailsresponse } from "./detailsresponse";
import { Productsresponse } from "./productsresponse";

export interface Cartresponse {
  id: string;
  userid: string;
  cartDetails: Detailsresponse[];
}
