// Libs
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Route, Switch } from 'react-router-dom'

//Style
import './index.css';


//Directories
import Home from './Pages/Home'
import Login from './Pages/Login'
import Menu from './Pages/Menu'
import Alunos from './Pages/Alunos'
import Equipe from './Pages/Equipe'
import reportWebVitals from './reportWebVitals';

ReactDOM.render(
  <BrowserRouter initialRoutName="Menu">
    <Switch>
      <Route name="/"       component={Home}    exact path="/" />
      <Route name="Home"    component={Home}    path="/Home" />
      <Route name="Login"   component={Login}   path="/Login"/>
      <Route name="Menu"    component={Menu}    path="/Menu"/>
      <Route name="Alunos"  component={Alunos}  path="/Alunos"/>
      <Route name="Equipe"  component={Equipe}  path="/Equipe"/>
    </Switch>
  </BrowserRouter>
  ,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
