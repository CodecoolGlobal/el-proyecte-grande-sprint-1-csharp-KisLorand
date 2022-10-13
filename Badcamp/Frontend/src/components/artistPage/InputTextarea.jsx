import React, { useState, useRef, useEffect } from 'react';
import './InputTextarea.css';

const InputTextarea = ({id,placeholder}) => {
 
  return (
    <div>
    <label className="input-sizer stacked">
      <textarea id={id} rows="1" placeholder={placeholder}></textarea>
    </label>
    </div>
  );
};

export default InputTextarea;