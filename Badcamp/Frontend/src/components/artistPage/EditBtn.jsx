import React from 'react';

const EditBtn = ({ref}) => {
    
  return (
    <button onClick={ref.current = true}>
      Edit
    </button>
  )
};

export default EditBtn;
