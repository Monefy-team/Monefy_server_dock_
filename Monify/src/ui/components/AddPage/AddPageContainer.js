import React, { Component } from "react";
import AddPageComponent from "./AddPageComponent";
import { push } from "connected-react-router";
import { func, string } from "prop-types";
import { connect } from "react-redux";
import {addPageComponent, addPageElement } from '../../../reduxStore/add/actions'
import axios from 'axios'

// import {addPageReducer} from "../../../reduxStore/add/reducer";

const propTypes = {
  push: func,
  SaveClick: func,
  AddItem: func,
  CloseClick: func,
  handleChangeName: func,
  handleChangeGrn: func,
  name: string,
  value: string
};

class AddPAgeContainer extends Component {

  /**
   * 
   * @param {*} props property to constructor
   * @constructor constructor create new states 
   * @var {string} name create name
   * @var {string} value create name
   * @var {Array} addData create name
   *   
   */
  constructor(props) {
    super(props);
    this.state = {
      name: "",
      value: "",
      addData: []
    };

    this.CloseClick = this.CloseClick.bind(this);
    this.SaveClick = this.SaveClick.bind(this);
    this.handleChangeName = this.handleChangeName.bind(this);
    this.handleChangeValue = this.handleChangeValue.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.addItem = this.addItem.bind(this);
  }

  maxId = 100;

  CloseClick = () => {
    console.log("piska Close");
  };

  SaveClick = () => {
    console.log("piska Save");
  };

  handleChangeName = event => {
    this.setState({ name: event.target.value });
  };

  handleChangeValue = event => {
    this.setState({ value: event.target.value });
  };

  

  handleSubmit = async (e) => {
    this.Post();
    e.preventDefault();
    console.log("-було надіслано: " + this.state.name);
    console.log("-було надіслано: " + this.state.value);
    console.log(this.state);
    const { push, addPageComponent, addPageElement} = this.props;
    if ( this.state.name.length <= 0 || this.state.value.length <= 0) {
      return null
    } else if (this.state.addData.length > 2) {

      addPageElement();
    }
      else {
        /**
         * @param {axios} axios.post method that crate account 
         * @param {string} username
         * @param {string} email 
         */
      addPageComponent();
    push("/friends");
    }
  };

  addItem = () => {
    
  };

  
  Post(){
    axios.post("user",{
      username:this.state.name,
      email:this.state.value
    })
  }

  render() {
    return (
      <>
        <AddPageComponent
          SaveClick={this.SaveClick}
          CloseClick={this.CloseClick}
          handleChangeName={this.handleChangeName}
          handleChangeValue={this.handleChangeValue}
          handleSubmit={this.handleSubmit}
          createAccount={this.addItem}
        />
      </>
    );
  }
}

const mapStateToProps = state => {
  return {
    name: state.addPageReducer.name,
    value: state.addPageReducer.value,
    ReducerAddData: state.addPageReducer.data
  };
};
const mapDispatchToProps = {
  push,
  addPageComponent,
  addPageElement,
};

/**
 * 
 * @param {number} x  argument
 * @param {number} y  argumnet
 * @description return sum of x and y  
 */
function sum2(x,y){
	return x + y;
}


AddPageComponent.propTypes = propTypes;

export default connect(mapStateToProps, mapDispatchToProps)(AddPAgeContainer);
