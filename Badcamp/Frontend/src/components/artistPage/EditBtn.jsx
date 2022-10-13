import React from 'react';
import { useEffect } from 'react';

const EditBtn = (btnprops) => {
    const [toggleState, setToggleState] = btnprops.toggle;
    const [editState, setEditState] = btnprops.edit;

    const toggleButtonState = (toggleState) => {
        setToggleState(toggleState === true ? false : true);
        if (toggleState===true) {
            UpdateData();
        }
    };

    const UpdateData = () => {
        const name = document.getElementById("artist-name-edit");
        const artistName = name.value.length === 0 ? name.placeholder : name.value; 
        
        const desc = document.getElementById("artist-description-textarea");
        const artistDescription = desc.value.length === 0 ? desc.placeholder : desc.value; 

        const UpdateObj = {
            id: btnprops.artist.id,
            name: artistName,
            description: artistDescription,
            profilePicture: btnprops.pfp
        };

        fetch(`${process.env.REACT_APP_BASE_URL}api/ArtistPage/${btnprops.artist.id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(UpdateObj),
        })
        .then((response) => {
            console.log(response, "response");
            if (response.status !== 200) {
            console.log("not ok" + response.status);
            }
            setEditState(editState === true ? false : true);
        })
        .catch((err) => {
            console.log(err);
        });
    };

  return (
    <button onClick={()=>toggleButtonState(toggleState)}>
      {toggleState === true ? "Save" : "Edit"}
    </button>
  )
};

export default EditBtn;
