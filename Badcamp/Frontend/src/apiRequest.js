import { RequestContext } from "./requestContext";

const apiRequest = async (url='', optionsObj=null, errMsg=null) => {
    try {
        const response = await fetch(url, optionsObj);
        if (!response.ok) throw Error('Error occoured. Reload the app');
    } catch (error) {
        errMsg = error.message;
    } finally {
        return errMsg;
    }
};

export const apiRequestGet = async (url='', optionsObj=null, errMsg=null) => {
    try {
        const response = await fetch(url, optionsObj);
        if (!response.ok) throw Error('Error occoured. Reload the app');
        const data = response.json;
        RequestContext(data);
    } catch (error) {
        errMsg = error.message;
    } finally {
        return errMsg;
    }
};

export default apiRequest;