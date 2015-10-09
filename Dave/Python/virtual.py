class Base:
    def Go(self):
        self.V()

class A(Base):
    def V(self):
        print("A")

class B(Base):
    def V(self):
        print("B")

a = A()
b = B()
a.Go()
b.Go()
