select
	Ips.IpAddr,
	le.Date,
	le.QueryType,
	fd.FileType,
	fd.Size,
	fd.FullName
from
	FileDatas as fd,
	ApacheLogEntries as le,
	Ips 
where
	le.FileId = fd.Id AND
	le.IpAddressId = Ips.Id
order by
	le.Date ASC