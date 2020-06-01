/* eslint-disable react/prefer-stateless-function */
import React, { Component } from "react";
import { connect } from "react-redux";
import ErrorModal from "../Modals/ErrorModal/ErrorModal";


class ModalRoot extends Component {
    render() {
        const MODAL_COMPONENTS = {
            USER_SEARCH_BAR_MODAL: ErrorModal,
            /* other modals */
        };
        if (!this.props.modalType) {
            return null;
        }
        const SpecificModal = MODAL_COMPONENTS[this.props.modalType];
        return <SpecificModal {...this.props.modalProps} />;
    }
}

const mapStateToProps = ({ modalReducer }) => {
    return {
        modalType: modalReducer.modalType
    };
};

export default connect(mapStateToProps)(ModalRoot);
