const fs = require('fs');
const path = require('path');

var copyRecursiveSync = function(src, dest) {
  var exists = fs.existsSync(src);
  var stats = exists && fs.statSync(src);
  var isDirectory = exists && stats.isDirectory();
  if (exists && isDirectory) {
    fs.mkdirSync(dest);
    fs.readdirSync(src).forEach(function(childItemName) {
      copyRecursiveSync(path.join(src, childItemName),
                        path.join(dest, childItemName));
    });
  } else {
    fs.linkSync(src, dest);
  }
};

fs.exists('./src/app/navigation', result => {
    if (!result) {
        copyRecursiveSync('../../Navigation/', './src/app/navigation');
        console.log("Navigation folder copied")
    }
});
