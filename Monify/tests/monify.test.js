const getUsers = require('../src/test');



test('test get method', () => {
    getUsers()
    .then(x => {
        expect(x.data.length()).toBe(5); 
    })
    .catch(err => {
        console.error(err);
    })
});



