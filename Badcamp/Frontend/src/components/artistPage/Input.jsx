import React from "react";
import { useContext } from "react";

const Input = ({ id, type, label, placeholder, ...rest }) => {
  return (
    <div>
      <input
        role="input"
        aria-label="input field"
        id={id}
        type={type}
        placeholder={placeholder}
      />
    </div>
  );
};




export default Input;