import React from 'react'

const ToggleButton = (btnprops) => {
    const [toggleState, setToggleState] = btnprops.toggle;

    const toggleButtonState = (toggleState) => {
        setToggleState(toggleState === true ? false : true);
    };

  return (
    <button onClick={ () => {toggleButtonState(toggleState)} }>
        {toggleState ? 'Event' : 'Song'}
    </button>
  )
};

export default ToggleButton;