const chokidar = require("chokidar"),
  fs = require("fs-extra"),
  path = require("path"),
  deepmerge = require("deepmerge");

var pkg = require("./package.json"),
  pkgIdeaBox = require("./Server/IdeaBox/dnn.json"),
  pkgIdeaBoxCore = require("./Server/Core/dnn.json");
if (fs.existsSync("./local.json")) {
  var local = require("./local.json");
  pkg = deepmerge(pkg, local);
}

var log = console.log.bind(console);

function copy(start, srcRelativePath, destDir) {
  if (!fs.existsSync(srcRelativePath)) {
    return null;
  }
  var relPath = path.relative(start, srcRelativePath);
  const fullDestPath = path.join(destDir, relPath);
  log("Copying: " + srcRelativePath);
  return fs
    .ensureDir(path.dirname(fullDestPath))
    .then(() => fs.copy(srcRelativePath, fullDestPath));
}

var ignore = [
  /obj/,
  /bin/,
  "**/*.{vb,cs,suo,user}",
  "**/dnn.json",
  "**/*.??proj",
  "**/web*.config",
  "**/packages.config",
  "**/.*"
];

const allDlls = pkgIdeaBox.pathsAndFiles.assemblies
  .concat(pkgIdeaBoxCore.pathsAndFiles.assemblies)
  .map(dll => "bin/" + dll);

const watcher = (src, dest) =>
  chokidar
    .watch(src, {
      ignored: ignore,
      persistent: true
    })
    .on("add", path => copy(src, path, dest))
    .on("change", path => copy(src, path, dest));
// Todo: delete events?

// Initialize watchers.
const IdeaBoxWatcher = watcher(
  "Server/IdeaBox",
  pkg.dnn.pathsAndFiles.devSitePath +
    "\\DesktopModules\\MVC\\Connect\\IdeaBox"
);

const DllWatcher = chokidar
  .watch(allDlls, {
    persistent: true
  })
  .on("add", path => {
    copy("bin", path, pkg.dnn.pathsAndFiles.devSitePath + "\\bin");
    copy(
      "bin",
      path.replace(".dll", ".pdb"),
      pkg.dnn.pathsAndFiles.devSitePath + "\\bin"
    );
  })
  .on("change", path => {
    copy("bin", path, pkg.dnn.pathsAndFiles.devSitePath + "\\bin");
    copy(
      "bin",
      path.replace(".dll", ".pdb"),
      pkg.dnn.pathsAndFiles.devSitePath + "\\bin"
    );
  });