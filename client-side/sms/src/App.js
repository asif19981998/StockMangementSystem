import React from "react";


import "./components/core/rippleButton/RippleButton"
import Router from "./Router"
import "react-perfect-scrollbar/dist/css/styles.css"
import "prismjs/themes/prism-tomorrow.css"

import "./components/core/rippleButton/RippleButton";

import "react-perfect-scrollbar/dist/css/styles.css";
import "prismjs/themes/prism-tomorrow.css";


import { Provider } from "react-redux";

import {  Switch, Route } from 'react-router-dom';
import { ToastProvider } from "react-toast-notifications";
import { Container } from "@material-ui/core";





;





const App = (props) => {
  // return <Router />
 return (
  
  <Router />
  
  //  <Router>
  //      <Provider store={store}>
  //     <ToastProvider autoDismiss={true}>
  //   <Container maxWidth="lg">
   

  //    <Switch>
  //    <Route path="/" exact component={LoginForm}/>
  //    <Route path="/countryList" component={CountryList}/>
  //    <Route path="/stateList" component={StateList}/>
  //    <Route path="/employeeList" component={EmployeeList}/>
  //    <Route path="/clientList" component={ClientList}/>
  //    <Route path="/companyInformationList" component={CompanyContactInformationList}/> 
  //    <Route path="/contactInformationList" component={ContactInformationList}/>   
  //    <Route path="/mainTable" component={MainTable}/>  
  //    <Route path="/enhancetable" component={EnhancedTable}/>  
  //    <Route path="/test" component={Test}/>  

  //      </Switch>

  //   </Container>
  // </ToastProvider>
  //  </Provider>
  //  </Router>
  
  
  // // <EnhancedTable/>
  // <MainTable/>

 )
}

export default App
