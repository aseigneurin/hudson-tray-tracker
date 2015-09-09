# Release Procedure

## Pre-Release Procedures:
- Update **\common\VersionInfo.cs**
```
[assembly: System.Reflection.AssemblyFileVersion("x.x.x.0")]
[assembly: System.Reflection.AssemblyInformationalVersion("x.x.x.0")]
```
- Create an alpha tag, like **v1.0.3-alpha**
- Commit changes and push to GitHub.

## Pre-Release Notes Procedures:
1. Draft a new release on GitHub, https://github.com/zionyx/jenkins-tray/releases/new

2. Find out all the closed issues against a certain milestone: https://github.com/zionyx/jenkins-tray/milestones

3. Use the recent alpha tag

4. Use previous releases as guides, will update it here soon.

5. Mark release as **This is a pre-release**.

6. Publish release.