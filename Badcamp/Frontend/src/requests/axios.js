import axios from "axios";

/*backend address*/
export default axios.create({
    baseURL: 'https://localhost:7151'
});