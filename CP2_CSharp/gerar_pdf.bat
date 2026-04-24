@echo off
echo ======================================
echo   Gerar PDF do Relatório
echo ======================================
echo.
echo Abrindo browser para impressão em PDF...
echo.
echo PASSOS:
echo 1. O navegador vai abrir
echo 2. Pressione Ctrl+P (ou menu > Imprimir)
echo 3. Em destino, escolha "Salvar como PDF"
echo 4. Clique em Salvar
echo.
pause

start "" "C:\Program Files\Google\Chrome\Application\chrome.exe" "Relatorio_Checkpoint2.html"

echo.
echo Após salvar o PDF, pressione qualquer tecla para sair...
pause >nul
