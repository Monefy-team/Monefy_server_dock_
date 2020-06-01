import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './ui/styles/reset.scss';
import { Provider } from 'react-redux';
import configureStore from './reduxStore/store';
import axios from 'axios'

axios.defaults.baseURL = "https://localhost:44333/api/"

const store = configureStore({});

ReactDOM.render(
	<Provider store={store}>
		<App />
	</Provider>,
	document.getElementById('root')
);

/**
 * 
 * @param {number} x  argument
 * @param {number} y  argumnet
 * @description return sum of x and y 
 */
function sum(x,y){
	return x + y;
}
