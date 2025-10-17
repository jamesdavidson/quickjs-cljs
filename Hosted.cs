#:package Jurassic@3.2.9
#:property PublishAot=false
using Jurassic;
var engine = new ScriptEngine();
engine.SetGlobalValue("console", new Jurassic.Library.FirebugConsole(engine));

engine.Execute("var print = console.log;");
engine.SetGlobalFunction("print", new Action<string>(Console.WriteLine));

engine.SetGlobalFunction("loadScript", new Action<string>(s => engine.ExecuteFile(s)));
engine.SetGlobalFunction("loadFile", new Func<string, string>(s => System.IO.File.ReadAllText(s)));

var preamble = @"
CLOSURE_NO_DEPS = true;

CLOSURE_IMPORT_SCRIPT = function(src, opt_sourceText) {
  var ret = true;
  try {
    if (src.startsWith('goog/')) {
      loadScript('clojurescript/out/'+src);
    } else {
      loadScript('clojurescript/out/'+src.replace('../',''));
    }
  } catch (err) {
    print('CLOSURE_IMPORT_SCRIPT: '+err);
    ret = false;
  }
  print('CLOSURE_IMPORT_SCRIPT: '+src+' '+ret); // debug
  return ret;
}

CLOSURE_LOAD_FILE_SYNC = function(src) {
  print('CLOSURE_LOAD_FILE_SYNC: '+src); // debug
  return loadFile('clojurescript/out/'+src);
};
";

engine.Execute(preamble);
engine.ExecuteFile("clojurescript/out/goog/base.js");

engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/debug/error.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/dom/NodeType.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/string/string.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/asserts/asserts.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/array/array.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/object/object.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/string/stringbuffer.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/reflect/reflect.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/math/math.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/math/integer.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/math/long.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/functions/functions.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/iter/iter.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/structs/structs.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/structs/map.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/uri/utils.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/uri/uri.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/labs/useragent/util.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/labs/useragent/browser.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/labs/useragent/engine.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/labs/useragent/platform.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/useragent/useragent.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/useragent/product.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/crypt/crypt.js');");
engine.Execute("CLOSURE_IMPORT_SCRIPT('goog/crypt/base64.js');");
