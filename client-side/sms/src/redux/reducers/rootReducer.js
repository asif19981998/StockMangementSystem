import { combineReducers } from "redux"
import chatReducer from "./chat/"
import customizer from "./customizer/"
import auth from "./auth/"

import { product } from "./core/product/product";


import { stock } from './core/state/stock';


import {city} from '../reducers/core/city/city';




const rootReducer = combineReducers({
  chatApp: chatReducer,
  customizer: customizer,
  auth: auth,
  product,
 
  city,
  stock,
 

})

export default rootReducer
