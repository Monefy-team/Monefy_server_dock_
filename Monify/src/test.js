const axios = require('axios');

async function getUsers() {
    const response = await axios.get("user");
    return response.data.length;
}

async function createUser(username,email) {
    return  await axios.post("user",{
        username:username,
        email:email
    });
}

//module.exports = getUsers;
