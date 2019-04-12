select
	*
from
	Beer
begin transaction

insert into
	Beer
values
	('Extra Stout', 'Guinness', 'Ireland', 18.90, 'Bottle'),
	('ShipFullOfIPA', 'Brutal Brewing', 'Sweden', 60.0, 'Can'),
	('Export', 'Falcon', 'Sweden', 10.0, 'Bottle')
rollback transaction
commit transaction