const Sequelize = require('sequelize');

module.exports = function (sequelize) {
    let Task = sequelize.define('Task', {

        title:Sequelize.TEXT,

        status:Sequelize.TEXT
    });

    return Task;
};