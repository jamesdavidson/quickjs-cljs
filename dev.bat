cd clojurescript
clj -M -m cljs.main --optimizations none --compile-opts "{:target :none}" -c hw.core
cd ..