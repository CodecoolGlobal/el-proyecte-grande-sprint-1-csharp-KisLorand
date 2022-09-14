import { RequestContext } from "./requestContext";

const apiRequest = async (url='', optionsObj=null, errMsg=null) => {
    try {
        const response = await fetch(url, optionsObj);
        if (!response.ok) throw Error('Error occoured. Reload the app');
        if (optionsObj === null) {
            const data = response.json;
            RequestContext(data);
        }
    } catch (error) {
        errMsg = error.message;
    } finally {
        return errMsg;
    }
};

export default apiRequest;