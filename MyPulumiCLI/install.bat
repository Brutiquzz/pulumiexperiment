@echo off
setlocal

echo Installing pulumictl...

:: Set install directory
set "INSTALL_DIR=%ProgramFiles%\pulumictl"

:: Get directory of this script
set "SCRIPT_DIR=%~dp0"

:: Show paths
echo Source directory: %SCRIPT_DIR%
echo Install directory: %INSTALL_DIR%

:: Create install folder if it doesn't exist
if not exist "%INSTALL_DIR%" (
    mkdir "%INSTALL_DIR%"
)

:: Copy the CLI tool from script's location
if exist "%SCRIPT_DIR%pulumictl.exe" (
    copy /Y "%SCRIPT_DIR%pulumictl.exe" "%INSTALL_DIR%\pulumictl.exe"
    echo ✅ pulumictl.exe copied successfully.
) else (
    echo ❌ ERROR: pulumictl.exe not found in script directory.
    pause
    exit /b 1
)

:: Add to user PATH (does not update current shell)
echo Adding to PATH...
setx PATH "%PATH%;%INSTALL_DIR%"

echo.
echo ✅ pulumictl installed to: %INSTALL_DIR%
echo 💡 You may need to restart your terminal or log out/in for PATH changes to take effect.
echo 🚀 Try running: pulumictl version
endlocal
pause
