@echo off
setlocal

echo Installing pulumictl...

:: Set install directory
set INSTALL_DIR=%ProgramFiles%\pulumictl

:: Create folder if it doesn't exist
if not exist "%INSTALL_DIR%" (
    mkdir "%INSTALL_DIR%"
)

:: Copy the CLI tool
copy /Y pulumictl.exe "%INSTALL_DIR%\pulumictl.exe"

:: Add to PATH (user environment)
echo Adding to PATH...
setx PATH "%PATH%;%INSTALL_DIR%"

echo.
echo ? pulumictl installed to: %INSTALL_DIR%
echo ?? You may need to restart your terminal or computer to refresh PATH
echo ?? Try running: pulumictl new
endlocal
pause
