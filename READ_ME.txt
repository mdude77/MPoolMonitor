General
- This is written for .Net 4.0.  This means windows only.  Maybe someday I'll try port it to another dev environment that can build for multiple OSs.
- Configuration is stored in the registry at HKCU\Software\MMiningMonitor.
- If a pool's hash rate says API ERRORx, run your cursor over it to see the underlying error message.  Probably related to the pool web site having a problem, or something wrong with your API info.  To confirm your key is right, go to the appropriate URL for your pool with that key and look at the output.  If it looks like a bunch of gobbly gook, with {braces} and commas, then the key should be good.  If it says something else, the key is likely the culprit.
- The Avg hashrate listed for workers is the average of the last 60 readings for that worker.  
- It can store statistics in a local MS Access database.  Right now, if enabled, it stores worker hash rates, pool hash rate, your total hash rate, and share counts per refresh interval.  This is an Access 2007 DB, so if you aren't Access savvy, this won't mean anything to you.  With enough demand, I can make this exportable from the app in a .CSV file for your use.
- It can auto refresh every 5 minutes up to every 60 minutes, and/or refresh on demand.
- There isn't anything more to this than meets the eye.  It doesn't "dial home" or look for wallets.  It does what it says, and nothing more.  That said...
- I intend to post the code to GitHub once I figure out how to use it. :)  In the meantime, if someone would like a copy for their perusal and local use (not distribution), please PM me.

Blockchain.info
- These stats come from the API on http://blockchain.info.  There are tons more stats available, I'm only showing what I thought would be of most importance to miners.  
- The estimated next difficulty is based upon the current avg time between blocks.  The formula is (10 / avg_time) * current_difficulty, as BTC is designed to have a block 
every 10 minutes, and will retarget every 2016 blocks to get it back to 10 minutes.

Eligius
- Averages for Eligius intentionally only show for the 256 second reading.  (The average routine is what feeds the "idle worker" logic.)
- Showing the luck values for anything other than "last 10 blocks luck" requires DB stats to be enabled and working.  If you don't have Microsoft Access 2007 or higher on your 
machine, you can install the Microsoft ACE Engine from https://www.microsoft.com/en-us/download/details.aspx?id=13255.  Be sure to use the 32-bit version, not the 64-bit 
version.
- The luck values for Eligius update once an hour.
- Sometimes the "balance last block" comes back from Eligius as "N/A".
- The API from Eligius doesn't currently properly support worker names in _format.  It only reports the total across all the _workers.

Idle worker alerts
- An "idle" worker is one who's had a non zero hash rate for at least 5 minutes and now has a zero hash rate for at least 5 minutes.
- EMail alerts don't seem to work with all email servers.  I'm using out of the box email functionality, and apparently in true Microsoft fashion, it doesn't work with all 
servers.  I know it works with google servers, and last I checked, it does not work with Verizon's servers.  I'd like to fix this some day as time permits.
- 50BTC doesn't provide worker hashrates in their API.  That means idle worker alerts won't work for this pool.

P2Pool
- The EstimatedBTC in the Payouts table is the "ideal payout @ 24 hours" value.


ScryptGuild
- There is a "lowdifficulty" share count that is included in the "bad" percentage, but otherwise not shown.
- The user hash rate comes from the worker data.  If the worker data option is turned off, you won't see the user hash rate.

Donations in BTC is what keeps this going!  1EARjDYEY2kKX6xwBuypEBs6BzPn4pWBku
However, don't forget to support your favorite pool and mining software too!  If it's fee free, give them a little something back!