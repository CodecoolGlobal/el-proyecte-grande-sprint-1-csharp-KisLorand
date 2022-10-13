import React from "react";
import { useContext } from "react";

const Input = ({ id, type, label, placeholder, value, artist, ...rest }) => {

  const HandleValueChange = (value) => {
    console.log(value)
  }

  return (
    <div>
      <input
        role="input"
        aria-label="input field"
        id={id}
        type={type}
        placeholder={placeholder}
/*         value={value}
        onChange={(e) => {HandleValueChange(e.target.value)}}
        onInput={e => HandleValueChange(e.target.value)} */
      />
    </div>
  );
};




export default Input;