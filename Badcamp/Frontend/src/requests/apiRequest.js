import React from "react";


const apiRequest = async (url='', [artist, setArtist], optionsObj=null, errMsg=null) => {
    try {
        const response = await fetch(url, optionsObj);
        if (!response.ok) throw Error('Error occoured. Reload the app');
        if (optionsObj === null) {
            const data = await response.json();
            setArtist(data);
        }
    } catch (error) {
        errMsg = error.message;
    } finally {
        return  errMsg;
    }
};

export default apiRequest;