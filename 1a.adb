with Ada.Text_IO;           use Ada.Text_IO;
with Ada.Integer_Text_IO;   use Ada.Integer_Text_IO;

procedure Hello is
    N : Integer;
    S : Integer := 0;
begin
    while not Ada.Text_IO.End_Of_File loop
        Get(N);
        S := S + N/3 - 2;
        Skip_Line;
    end loop;
    Put_Line(Integer'Image(S));
end Hello;
