const fs = require('fs-extra');
fs.exists('./src/app/navigation', result => {
    if (!result) {
        fs.ensureSymlink('../../Navigation/', './src/app/navigation', 'dir').then(() => {
            console.log("Symbolic link setup done");
        });
    }
});
