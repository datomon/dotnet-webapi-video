## 關於

    ASP.NET Core WebAPI 專案影片回傳語法，目標情境為：
    (1) 回傳給前端的影片是可以跳進度的 (HTTP Code 206)
    (2) 情況要區分檔案是否於網站前端目錄下 (wwwroot)

## 開發環境

- .NET 5

## 用法

    (1) 要放網站前端目錄下的影片放 wwwroot/videos 目錄，反之則放在專案目錄下的 videos 目錄 (videos 目錄自行建立)
    (2) 用終端機 cd 進專案目錄後，輸入指令：dotnet watch run
