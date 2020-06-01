import { SET_PAGE_COMPONENT } from "./actionType";
import { SET_PAGE_ELEMENT } from "./actionType";
const initialState = {
  // name:'',
  // value:'',
  data: [],
};

export function addPageReducer(state = initialState, action) {
  switch (action.type) {
    case SET_PAGE_COMPONENT:
      return {
        ...state,
        // name: action.name,
        // value: action.value,
        data: state.data.map((item) => {
          if (item.length >= 2) {
            return {
              data: action.data,
            };
          }
          return {
            ...item,
            data: action.data,
          };
        }),
      };
    case SET_PAGE_ELEMENT:
      return {
        ...state,
        data: state.data.map((item, index) => {
          if (index > 2) {
            return {
              ...item,
              data: action.payload.data,
            };
          }
          return {
            ...item,
            data: action.payload.data,
          };
        }),
      };
    default:
      return state;
  }
}
