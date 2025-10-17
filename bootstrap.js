CLOSURE_IMPORT_SCRIPT = function(src, opt_sourceText) {
  var ret = true;
  try {
    if (src.startsWith("goog/")) {
      std.loadScript("clojurescript/out/"+src);
    } else {
      std.loadScript("clojurescript/out/"+src.replace("../",""));
    }
  } catch (err) {
    print("CLOSURE_IMPORT_SCRIPT: "+err);
    ret = false;
  }
  print("CLOSURE_IMPORT_SCRIPT: "+src+" "+ret); // debug
  return ret;
}

CLOSURE_LOAD_FILE_SYNC = function(src) {
  print("CLOSURE_LOAD_FILE_SYNC: "+src); // debug
  return std.loadFile("clojurescript/out/"+src);
};

console.error = console.log;

CLOSURE_IMPORT_SCRIPT("goog/debug/error.js");
CLOSURE_IMPORT_SCRIPT("goog/dom/NodeType.js");
CLOSURE_IMPORT_SCRIPT("goog/string/string.js");
CLOSURE_IMPORT_SCRIPT("goog/asserts/asserts.js");
CLOSURE_IMPORT_SCRIPT("goog/array/array.js");
CLOSURE_IMPORT_SCRIPT("goog/object/object.js");
CLOSURE_IMPORT_SCRIPT("goog/string/stringbuffer.js");
CLOSURE_IMPORT_SCRIPT("goog/reflect/reflect.js");
CLOSURE_IMPORT_SCRIPT("goog/math/math.js");
CLOSURE_IMPORT_SCRIPT("goog/math/integer.js");
CLOSURE_IMPORT_SCRIPT("goog/math/long.js");
CLOSURE_IMPORT_SCRIPT("goog/functions/functions.js");
CLOSURE_IMPORT_SCRIPT("goog/iter/iter.js");
CLOSURE_IMPORT_SCRIPT("goog/structs/structs.js");
CLOSURE_IMPORT_SCRIPT("goog/structs/map.js");
CLOSURE_IMPORT_SCRIPT("goog/uri/utils.js");
CLOSURE_IMPORT_SCRIPT("goog/uri/uri.js");


CLOSURE_IMPORT_SCRIPT("goog/labs/useragent/util.js");
CLOSURE_IMPORT_SCRIPT("goog/labs/useragent/browser.js");
CLOSURE_IMPORT_SCRIPT("goog/labs/useragent/engine.js");
CLOSURE_IMPORT_SCRIPT("goog/labs/useragent/platform.js");

CLOSURE_IMPORT_SCRIPT("goog/useragent/useragent.js");
CLOSURE_IMPORT_SCRIPT("goog/useragent/product.js");

CLOSURE_IMPORT_SCRIPT("goog/crypt/crypt.js");
CLOSURE_IMPORT_SCRIPT("goog/crypt/base64.js");

