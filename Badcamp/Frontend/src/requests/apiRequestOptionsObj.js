export const postOptions = (item) = {
    method: "POST",
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
};

export const updateOptions = (item) = {
    method: "PUT",
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
};

export const deleteOptions = {
    method: "DELETE"
};