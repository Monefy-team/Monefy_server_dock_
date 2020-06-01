import { SET_PAGE_COMPONENT } from "./actionType";
import { SET_PAGE_ELEMENT } from "./actionType";

export const addPageComponent = (data) => (dispatch) => {
  const element = {
    // name: name,
    // value: value,
    data: data,
  };
  dispatch({
    type: SET_PAGE_COMPONENT,
    ...element,
    // name: name,
    // value: value,
    data: data,
  });
};

export const addPageElement = (index, data) => (dispatch) => {
  dispatch({ type: SET_PAGE_ELEMENT, payload: { index, data } });
};
