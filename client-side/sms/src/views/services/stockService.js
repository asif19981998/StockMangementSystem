import axios from "axios";

import React, { Component } from 'react'

export default class StockService  {
    data = []
    constructor(){
        axios.get("https://localhost:44388/api/stock/GetChartData").then(
            response=>{
                response.data.forEach(element => {
                    var data = {
                        upazilaId:element.upazilaId,
                        quantity:element.quantity,
                        upazilaName:element.upazila.name
                    }
                     this.data.push(data)
                });
            }
        )
    }
}
