import React from "react"
import * as Icon from "react-feather"
const navigationConfig = [


{
  id:"product",
  title:"product",
  type:"collapse",
  icon: <Icon.Box size={20} />,
  permissions: ["admin", "editor"],
  children:[
    {
      id:"productList",
      title:"product List",
      type:"item",
      permissions: ["admin", "editor"],
      navLink: "/productList"

    },
    {
      id:"productCreate",
      title:"product Create",
      type:"item",
      
      permissions: ["admin", "editor"],
      navLink: "/productCreate"

    }
  ]
},
{
  id:"stock",
  title:"Stock",
  type:"collapse",
  icon: <Icon.Box size={20} />,
  permissions: ["admin", "editor"],
  children:[
    {
      id:"stockList",
      title:"Stock List",
      type:"item",
      permissions: ["admin", "editor"],
      navLink: "/stockList"

    },
    {
      id:"stockCreate",
      title:"Stock Create",
      type:"item",
      
      permissions: ["admin", "editor"],
      navLink: "/stockCreate"

    }
  ]
} ,


]

export default navigationConfig
