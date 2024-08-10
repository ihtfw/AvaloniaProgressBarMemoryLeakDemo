# AvaloniaProgressBarMemoryLeakDemo

Project to reproduce memory leak for ProgressBar

# Environment

- Windows 11
- .net 8
- Avalonia 11.1.2

# Steps to reproduce

- Run project
- Attach memory profiler. I've used dotMemory
- Create memory snapshot
- Click Run Test in application
- Wait until it finished
- Create memory snapshot
- Compare snapshots
- Now we see that 5 ProgressWindow objects are kept, but they should not!
